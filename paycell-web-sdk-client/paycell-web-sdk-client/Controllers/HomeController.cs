using paycell_web_sdk_client.Models.dto;
using paycell_web_sdk_client.Services;
using System;
using System.Web.Mvc;

namespace paycell_web_sdk_client.Controllers
{
    public class HomeController : Controller
    {
        private PaymentService paymentService;

        public HomeController()
        {
            paymentService = new PaymentService();
        }

        public ActionResult Welcome()
        {
            TempData["temp"] = paymentService.LoadTestData();
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            if (TempData["temp"] == null) {
                TempData["temp"] = paymentService.LoadTestData();
            }

            return View(TempData["temp"] as IndexPageViewDto);
        }

        [HttpPost]
        public ActionResult Index(IndexPageViewDto indexPageViewDto)
        {
            TempData["temp"] = indexPageViewDto;

            indexPageViewDto.PaymentView.PaymentReferenceNumber = paymentService.KeyGenerator();

            try
            {
                indexPageViewDto.PaymentUrl = paymentService.InitPayment(indexPageViewDto);

            } catch (Exception e)
            {
                indexPageViewDto.PaymentUrl = e.Message;
            }

            return View(indexPageViewDto);

        }
        
        public ActionResult New() // new InstallmentPlan
        {
            if (TempData["temp"] != null)
            {
                IndexPageViewDto indexPageViewDto = TempData["temp"] as IndexPageViewDto;
                indexPageViewDto.PaymentView.InstalmentPlans.Add(new InstalmentPlanViewDto());
                TempData["temp"] = indexPageViewDto;
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id) //delete InstallmentPlan
        {
            if (TempData["temp"] != null)
            {
                IndexPageViewDto indexPageViewDto = TempData["temp"] as IndexPageViewDto;
                indexPageViewDto.PaymentView.InstalmentPlans.RemoveAt(id);
                TempData["temp"] = indexPageViewDto;
            }
            return RedirectToAction("Index");
        }

        public ActionResult CheckStatus(string paymentReferenceNumber)
        {
            if (TempData["temp"] != null)
            {
                IndexPageViewDto indexPageViewDto = TempData["temp"] as IndexPageViewDto;

                var metaData = indexPageViewDto.MetaData;
                var queryStatu = new QueryStatuViewDto();
                var payment = indexPageViewDto.PaymentView;

                try
                {
                    queryStatu = paymentService.QueryPayment(indexPageViewDto.MetaData, indexPageViewDto.PaymentView);
                    ViewBag.successMessage = "CheckStatus Success!";
                }
                catch (Exception e)
                {
                    ViewBag.message = e.Message;
                }

                return View(Tuple.Create(metaData, queryStatu, payment));

            } else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Reverse()
        {
            MetaDataViewDto metaData = TempData["metaDataItem"] as MetaDataViewDto;
            QueryStatuViewDto queryStatu = TempData["queryStatuItem"] as QueryStatuViewDto;
            PaymentViewDto payment = TempData["paymentItem"] as PaymentViewDto;

            string reverse = null;

            try
            {
                reverse = paymentService.ReversePayment(metaData, payment);
                ViewBag.successMessage = "Reverse Success!";

            } catch (Exception e)
            {
                ViewBag.message = e.Message;
            }

            return View("CheckStatus", Tuple.Create(metaData, queryStatu, payment));
        }

        public ActionResult Refund(string refundAmount)
        {
            MetaDataViewDto metaData = TempData["metaDataItem"] as MetaDataViewDto;
            QueryStatuViewDto queryStatu = TempData["queryStatuItem"] as QueryStatuViewDto;
            PaymentViewDto payment = TempData["paymentItem"] as PaymentViewDto;

            string refund = null;

            try
            {
                refund = paymentService.RefundPayment(metaData, payment, refundAmount);
                ViewBag.successMessage = "Refund Success!";

            } catch (Exception e)
            {
                ViewBag.message = e.Message;
            }

            return View("CheckStatus", Tuple.Create(metaData, queryStatu, payment));
        }

    }
}
